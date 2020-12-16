using System;
using System.Runtime.InteropServices;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// A dictionary key used to lookup callback instances
    /// </summary>
    public struct InvocationRecord
    {
        public readonly ulong id;

        static ulong next;

        public static InvocationRecord Next()
        {
            var id = next++;
            return new InvocationRecord(id);
        }

        public InvocationRecord(HandleRef handle)
        {
            HandleRef.ToIntPtr(handle);
            id = next++;
        }

        public InvocationRecord(ulong id)
        {
            this.id = id;
        }
    }
}