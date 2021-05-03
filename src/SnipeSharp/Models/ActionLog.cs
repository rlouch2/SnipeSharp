using System;

namespace SnipeSharp.Models
{
    public sealed class ActionLog
    {
        public int Id { get; }
        public string Icon { get; }
        public ActionLogFile? File { get; }
        // TODO: item
        public Stub<Location>? Location { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public FormattedDateTime? NextAuditDate { get; }
        public TimeSpan DaysToNextAudit { get; }
        //public ActionType ActionType { get; }
        public StubUser? Admin { get; }
        // TODO: target
        public string? Note { get; }
        public Uri? SignatureFile { get; }
        // TODO: changes
        public FormattedDateTime? ActionDate { get; }
    }

    public sealed class ActionLogFile
    {
        public Uri Url { get; }
        public string FileName { get; }
        public bool IsInlineable { get; }
    }
}
