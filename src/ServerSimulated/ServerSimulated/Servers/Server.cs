namespace ServerSimulated.Servers
{
    public static class Server
    {
        private static int count = 0;

        private static readonly ReaderWriterLockSlim readerWriterLockSlim =
            new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public static int GetCount()
        {
            readerWriterLockSlim.EnterReadLock();
            try
            {
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] READ  -> {count}");

                return count;
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            readerWriterLockSlim.EnterWriteLock();

            try
            {
                count += value;

                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] WRITE +1");
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}