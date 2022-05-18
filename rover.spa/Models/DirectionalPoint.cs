namespace rover.spa.Models
{
    public enum Direction
    {
        N, E, S, W
    }


    public class DirectionalPoint
    {
        public DirectionalPoint(int x, int y, string _direction)
        {
            this.x = x;
            this.y = y;
            Enum.TryParse(_direction, out Direction startdirection);
            direction = startdirection;
        }


        public int x { get; set; }

       public int y { get; set; }

       public Direction direction { get; set; }

    }
}
