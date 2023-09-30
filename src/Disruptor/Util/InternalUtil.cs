using System;
using System.Runtime.CompilerServices;

namespace Disruptor.Util;

internal static class InternalUtil
{
    /// <summary>
    /// Ring buffer padding size in bytes.
    ///
    /// The padding should be added at the beginning and at the end of the
    /// ring buffer arrays.
    ///
    /// Used to avoid false sharing.
    /// </summary>
    public const int RingBufferPaddingBytes = 128;

    /// <summary>
    /// Gets the ring buffer padding as a number of events.
    /// </summary>
    /// <param name="eventSize"></param>
    /// <returns></returns>
    public static int GetRingBufferPaddingEventCount(int eventSize)
    {
        return (int)Math.Ceiling((double)RingBufferPaddingBytes / eventSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref T ReadValue<T>(IntPtr pointer, int index, int size)
        where T : struct
    {
        return ref Unsafe.AsRef<T>((void*)(pointer + index * size));
    }
}
