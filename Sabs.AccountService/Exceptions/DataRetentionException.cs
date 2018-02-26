using System;

namespace Sabs.AccountService.Exceptions
{
    /**
     * Thrown when Data is not to be deleted because it has a dependent record
     */
    public class DataRetentionException : Exception
    {
        public DataRetentionException() : base () {}
        public DataRetentionException(string message) : base(message) {}
    }
}
