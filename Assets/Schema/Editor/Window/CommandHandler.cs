using SchemaEditor.Internal.ComponentSystem;
using System.Collections.Generic;
using Schema;
using SchemaEditor.Internal.ComponentSystem.Components;
using System.Linq;

namespace SchemaEditor.Internal
{
    public static class CommandHandler
    {
        public static CopyBuffer copyBuffer { get { return _copyBuffer; } }
        private static CopyBuffer _copyBuffer;
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
                case "Cut":
                    CutCommand(canvas);
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
            _copyBuffer = new CopyBuffer(
                canvas,
                canvas.components
                    .Where(x => x is ICopyable)
                    .Cast<ICopyable>()
                    .Where(x => x.IsCopyable())
                    .Select(x => x.GetCopyable()),
                NodeEditor.instance.target
            );

            canvas.context.Rebuild();
            canvas.DeselectAll();
        }
        public static void PasteCommand(ComponentCanvas canvas)
        {
            copyBuffer.Flush(
                canvas.components
                    .Where(x => x is IPasteRecievier)
                    .Cast<IPasteRecievier>()
                    .Where(x => x.IsPastable())
                    .Select(x => x.GetReciever())
            );

            _copyBuffer = null;

            canvas.context.Rebuild();
        }
        public static void CutCommand(ComponentCanvas canvas)
        {
            IEnumerable<ICopyable> copyables = canvas.components
                .Where(x => x is ICopyable)
                .Cast<ICopyable>()
                .Where(x => x.IsCopyable());

            _copyBuffer = new CopyBuffer(
                canvas,
                copyables
                    .Select(x => x.GetCopyable()),
                NodeEditor.instance.target
            );

            foreach (IDeletable deletable in copyables
                .Where(x => x is IDeletable)
                .Cast<IDeletable>())
            {
                if (deletable.IsDeletable())
                    deletable.Delete();
            }

            canvas.context.Rebuild();
            canvas.DeselectAll();
        }
        private enum CopyBufferDescriptor
        {
            NodesWithConditionals,
            Conditionals,
        }
    }
}