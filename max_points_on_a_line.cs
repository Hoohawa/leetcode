public class Solution
{
    public class Line
    {
        private readonly Point p1;
        private readonly Point p2;

        public double Slope { get; set; }
        public double Offset { get; set; }
        public int PointCount { get; set; }

        public bool Contains(Point p)
        {
            if (p1.x == p2.x && p.x != p1.x)
            {
                return false;
            }
            else if (p1.x == p2.x && p.x == p1.x)
            {
                return true;
            }

            double y = p.y;
            double xSide = this.Slope * p.x + this.Offset;

            return Math.Abs(y - xSide) < 0.000001;
        }

        public Line(Point p1, Point p2)
        {
            this.Slope = (double)(p1.y - p2.y) / (p1.x - p2.x);
            this.Offset = p2.y - this.Slope * p2.x;
            this.PointCount = 0;
            this.p1 = p1;
            this.p2 = p2;
        }
    }

    private List<Line> lines = new List<Line>();

    public int MaxPoints(Point[] points)
    {
        // Add all possible lines
        for (var i = 0; i < points.Length - 1; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                this.lines.Add(new Line(points[i], points[j]));
            }
        }

        // For all possible lines if a point goes through it, increase the counter
        foreach (var line in this.lines)
        {
            foreach (var point in points)
            {
                if (line.Contains(point))
                {
                    line.PointCount++;
                }
            }
        }

        return this.lines.Count > 1
            ? this.lines.Max(l => l.PointCount)
            : points.Length;
    }
}