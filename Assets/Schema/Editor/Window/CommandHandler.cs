using SchemaEditor.Internal.ComponentSystem;
using System.Collections.Generic;
using Schema;
using SchemaEditor.Internal.ComponentSystem.Components;
using System.Linq;

namespace SchemaEditor.Internal
{
    public static class CommandHandler
    {
        public static CopyBuffer copyBuffer { get; }
        static CommandHandler()
        {
            copyBuffer = new CopyBuffer();
        }
        public static bool Valdiate(string commandName)
        {
            switch (commandName)
            {
                case "SoftDelete":
                case "Copy":
                case "Cut":
                case "Paste":
                case "Duplicate":
                case "SelectAll":
                case "DeselectAll":
                case "SelectChildren":
                    return true;
            }

            return false;
        }
        public static void Execute(ComponentCanvas canvas, string commandName)
        {
            switch (commandName)
            {
                case "SoftDelete":
                    DeleteCommand(canvas);
                    break;
                case "SelectAll":
                    SelectAllCommand(canvas);
                    break;
                case "DeselectAll":
                    DeselectAllCommand(canvas);
                    break;
                case "SelectChildren":
                    SelectChildrenCommand(canvas);
                    break;
                case "Copy":
                    CopyCommand(canvas);
                    break;
                case "Paste":
                    PasteCommand(canvas);
                    break;
            }
        }
        public static void DeleteCommand(ComponentCanvas canvas)
        {
            foreach (GUIComponent component in canvas.components.Where(x => x is IDeletable))
            {
                IDeletable deletable = (IDeletable)component;

                if (deletable.IsDeletable())
                {
                    deletable.Delete();

                    canvas.Deselect(component);
                    canvas.Remove(component);
                }
            }
        }
        public static void SelectAllCommand(ComponentCanvas canvas)
        {
            foreach (GUIComponent component in canvas.components)
                canvas.Select(component);
        }
        public static void DeselectAllCommand(ComponentCanvas canvas)
        {
            canvas.DeselectAll();
        }
        public static void SelectChildrenCommand(ComponentCanvas canvas)
        {
            if (!canvas.CanSelectChildren())
                return;

            IEnumerable<NodeComponent> nodeComponents = canvas.selected
                .Where(x => x is NodeComponent)
                .Cast<NodeComponent>();

            foreach (NodeComponent node in nodeComponents)
                SelectRecursive(node, canvas);
        }
        private static void SelectRecursive(NodeComponent nodeComponent, ComponentCanvas canvas)
        {
            foreach (NodeComponent child in nodeComponent.node.children.Select(x => canvas.FindComponent(x)))
                SelectRecursive(child, canvas);

            canvas.Select(nodeComponent);
        }
        public static void CopyCommand(ComponentCanvas canvas)
        {
            copyBuffer.Copy(
                canvas.components
                    .Where(x => x is ICopyable)
                    .Cast<ICopyable>()
                    .Where(x => x.IsCopyable())
                    .Select(x => x.GetCopyable())
            );

            canvas.context.Rebuild();
        }
        public static void PasteCommand(ComponentCanvas canvas)
        {
            copyBuffer.Paste(
                canvas.components
                    .Where(x => x is IPasteRecievier)
                    .Cast<IPasteRecievier>()
                    .Where(x => x.IsPastable())
                    .Select(x => x.GetReciever())
            );

            canvas.context.Rebuild();
        }
        private enum CopyBufferDescriptor
        {
            NodesWithConditionals,
            Conditionals,
        }
    }
}
