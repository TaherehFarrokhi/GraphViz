using System.Collections.Generic;

namespace GraphViz.Core.Domain
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private sealed class IdEqualityComparer : IEqualityComparer<Node>
        {
            public bool Equals(Node x, Node y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(Node obj)
            {
                return obj.Id;
            }
        }

        private static readonly IEqualityComparer<Node> IdComparerInstance = new IdEqualityComparer();

        public static IEqualityComparer<Node> IdComparer
        {
            get { return IdComparerInstance; }
        }
    }
}
