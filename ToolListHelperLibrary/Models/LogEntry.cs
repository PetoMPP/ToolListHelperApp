namespace ToolListHelperLibrary.Models
{
    public struct LogEntry
    {
        public long CreationTimestamp { get; set; }
        public int Position { get; set; }
        public string? Note { get; set; }
        public DateTime Date 
        { 
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(CreationTimestamp).DateTime;
            } 
        }
        public string UserName { get; set; }
        public static explicit operator LogEntryViewModel(LogEntry logEntry)
        {
            return new LogEntryViewModel()
            {
                Date = logEntry.Date,
                UserName = logEntry.UserName,
                Note = logEntry.Note,
                Position = logEntry.Position
            };
        }
    }
}