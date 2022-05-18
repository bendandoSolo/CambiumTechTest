using rover.spa.Models;


namespace rover.spa.Services
{
    public static class RoverServices
    {
        private static readonly char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly char[] directions = { 'N', 'S', 'E', 'W' };//could add lower cases

        //creates an array of Directional Points and returns 
        public static List<List<DirectionalPoint>> ProcessMovementsDataToLocationsData(List<string> csvData)
        {
            List<List<DirectionalPoint>> AllRoverPositions = new List<List<DirectionalPoint>>();


            foreach (string line in csvData)
            {
                List<DirectionalPoint> roverPos = new List<DirectionalPoint>();
                int position = line.IndexOf("|");
                string startingPositionData = line.Substring(0, position);
                string movementData = line.Substring(position + 1);

                ////start by setting that initial position data, refactor to method
                ////set xpos
                //int firstNumberPosition = startingPositionData.IndexOfAny(numbers);
                //Int32.TryParse(startingPositionData.Substring(firstNumberPosition, 1), out int xpos);
                ////set ypos
                //int secondNumberPosition = startingPositionData.IndexOfAny(numbers, firstNumberPosition + 1);
                //Int32.TryParse(startingPositionData.Substring(secondNumberPosition, 1), out int ypos);
                ////set initial orientation
                //DirectionalPoint dp = new DirectionalPoint(xpos, ypos, startingPositionData.Substring(startingPositionData.IndexOfAny(directions, secondNumberPosition), 1));
                //roverPos.Add(dp);
                roverPos.Add(ProcessInitialPositionData(startingPositionData));

                Direction currentOrientation = roverPos[0].direction;
                int xpos = roverPos[0].x;
                int ypos = roverPos[0].y;
                //process movements data
                foreach (char c in movementData)
                {
                    if (!Char.IsWhiteSpace(c))
                    {
                        switch (Char.ToUpper(c))
                        {
                            case 'M':
                                switch (currentOrientation)
                                {
                                    case Direction.N:
                                        ypos++;
                                        break;
                                    case Direction.E:
                                        xpos++;
                                        break;
                                    case Direction.S:
                                        ypos--;
                                        break;
                                    case Direction.W:
                                        xpos--;
                                        break;
                                    default:
                                        //potentially throw error here
                                        break;
                                }
                                break;
                            //use type conversion and modulus to go left or right
                            case 'R':
                                currentOrientation = (Direction)(((int)currentOrientation + 1) % 4);
                                break;
                            case 'L':
                                currentOrientation = (Direction)(((int)currentOrientation + 3) % 4);
                                break;
                            default:
                                //potentially throw error here
                                break;
                        }
                        roverPos.Add(new DirectionalPoint(xpos, ypos, currentOrientation.ToString()));
                    }
                }
                AllRoverPositions.Add(roverPos);
            }
            return AllRoverPositions;
        }


        public static DirectionalPoint ProcessInitialPositionData(string startingPositionData)
        {
            int firstNumberPosition = startingPositionData.IndexOfAny(numbers);
            Int32.TryParse(startingPositionData.Substring(firstNumberPosition, 1), out int xpos);
            //set ypos
            int secondNumberPosition = startingPositionData.IndexOfAny(numbers, firstNumberPosition + 1);
            Int32.TryParse(startingPositionData.Substring(secondNumberPosition, 1), out int ypos);
            //set initial orientation
            return new DirectionalPoint(xpos, ypos, startingPositionData.Substring(startingPositionData.IndexOfAny(directions, secondNumberPosition), 1));
        }




    }
}
