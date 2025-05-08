using Loyalty.Domain.Common;
using Loyalty.Domain.Users.Entities;

namespace Loyalty.Domain.Users
{
    public class User : AggregateRoot
    {
        public string Name { get; private set; }
        private List<Point> _points = new();
        public IReadOnlyCollection<Point> Points => _points.AsReadOnly();

        public User(string name)
        {
            Name = name;
        }

        public void AddPoints(int points)
        {
            _points.Add(new Point(points));
        }
    }
}
