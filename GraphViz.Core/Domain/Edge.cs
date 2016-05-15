using System.Collections.Generic;

namespace GraphViz.Core.Domain
{
    public class Edge
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }

        private sealed class SourceIdTargetIdEqualityComparer : IEqualityComparer<Edge>
        {
            public bool Equals(Edge x, Edge y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.SourceId == y.SourceId && x.TargetId == y.TargetId;
            }

            public int GetHashCode(Edge obj)
            {
                unchecked
                {
                    return (obj.SourceId*397) ^ obj.TargetId;
                }
            }
        }

        private static readonly IEqualityComparer<Edge> SourceIdTargetIdComparerInstance = new SourceIdTargetIdEqualityComparer();

        public static IEqualityComparer<Edge> SourceIdTargetIdComparer
        {
            get { return SourceIdTargetIdComparerInstance; }
        }
    }
}