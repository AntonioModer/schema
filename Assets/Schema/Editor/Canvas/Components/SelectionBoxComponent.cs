using Schema;
using SchemaEditor;
using SchemaEditor.Internal;
using UnityEngine;
using UnityEditor;
using System;

public sealed class SelectionBoxComponent : GUIComponent
{
    public Vector2 mouseDownPosition { get; set; }
    public bool hideOnMouseUp { get; set; }
    public bool hidden { get; set; }
    public Rect selectionRect { get { return _selectionRect; } }
    private Rect _selectionRect;
    private Vector2 lastSize;
    public override void Create(CreateArgs args)
    {
        SelectionBoxComponentCreateArgs createArgs = args as SelectionBoxComponentCreateArgs;

        if (createArgs == null)
            throw new ArgumentException();

        hideOnMouseUp = createArgs.hideOnMouseUp;
    }
    public override void OnGUI()
    {
        if (hidden)
            return;

        Event e = Event.current;

        if (hideOnMouseUp && e.type == EventType.MouseUp)
            hidden = true;

        Vector2 curPos = NodeEditor.WindowToGridPosition(e.mousePosition);
        Vector2 size = curPos - mouseDownPosition;
        Rect r = new Rect(mouseDownPosition, size);
        r.position = NodeEditor.GridToWindowPosition(r.position);
        r.size /= NodeEditor.instance.windowInfo.zoom;

        _selectionRect = r;

        Handles.DrawSolidRectangleWithOutline(r, new Color(0, 0, 0, 0.1f), new Color(1, 1, 1, 0.6f));
    }
    public class SelectionBoxComponentCreateArgs : CreateArgs
    {
        public bool hideOnMouseUp { get; set; }
    }
}