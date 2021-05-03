using System.Collections.Generic;
using System.Text;

namespace SnipeSharp
{
    internal sealed class StringJoiner
    {
        private readonly StringBuilder Builder;
        private readonly string Between;
        private readonly string After;

        public uint JoinedItemsCount { get; private set; } = 0;

        internal StringJoiner(): this("", ",", ""){}
        internal StringJoiner(string between): this("", between, ""){}
        internal StringJoiner(string before, string between, string after)
        {
            Builder = new StringBuilder(before);
            Between = between;
            After = after;
        }

        public StringJoiner Append(string next)
        {
            if(JoinedItemsCount > 0)
                Builder.Append(Between);
            Builder.Append(next);
            JoinedItemsCount += 1;
            return this;
        }

        public override string ToString()
            => Builder.Append(After).ToString();
    }

    internal static class StringJoinerExtensions
    {
        internal static string Join(this IReadOnlyDictionary<string, string> self)
            => self.Join("", ",", "");
        internal static string Join(this IReadOnlyDictionary<string, string> self, string between)
            => self.Join("", between, "");
        internal static string Join(this IReadOnlyDictionary<string, string> self, string before, string between, string after)
        {
            var joiner = new StringJoiner(before, between, after);
            foreach(var pair in self)
                joiner.Append(pair.ToString());
            return joiner.ToString();
        }
    }
}
