using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace SchemaEditor.Internal.ComponentSystem
{
    public interface ICopyable
    {
        bool IsCopyable();
        Object GetCopyable();
    }
}