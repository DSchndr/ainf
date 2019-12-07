namespace _4gewinnt
{

    class GameLogic
    {

        //Go over field and check if game is won
        public static bool checkfield(int Row, int Col)
        {
            GameLogic gl = new GameLogic();
            if (gl.checkdiags(Row, Col) || gl.isdiagonal(Row, Col)) return true;
            return false;
        }

        private bool isdiagonal(int Row, int Col)
        {
            var color = GameVariables.blockarr[Row, Col]; //farbe die gematched werden soll
            var matches = 1; //anzahl matches
            /*
            ******
            ******
            ******
            *P****
            *X****
            *X****
            *X****
            */
            //nach unten
            for (int count = 1; count < 4; count++)
            {
                var row = Row - count;
                if (row < GameVariables.blockarr.GetLowerBound(0) || row >= 7 || Row > 4) { break; }

                if (GameVariables.blockarr[row, Col] == color)
                {
                    matches++;
                    if (matches == 4) return true;
                }
                else { break; }
            }
            /*
            ******
            ******
            **X***
            **X***
            **X***
            **P***
            ******
            */
            //nach oben
            for (int count = 1; count < 4; count++)
            {
                var row = Row + count;
                if (row < GameVariables.blockarr.GetLowerBound(0) || row >= 7 || Row < 3) { break; }

                if (GameVariables.blockarr[row, Col] == color)
                {
                    matches++;
                    if (matches == 4) return true;
                }
                else { break; }
            }
            matches = 1;
            /*
            ******
            ******
            ******
            ******
            *PXXX*
            ******
            ******
            */
            //nach rechts
            for (int count = 1; count < 4; count++)
            {
                var column = Col + count;
                if (column < GameVariables.blockarr.GetLowerBound(1) || column >= 6 || Col > 3) { break; }

                if (GameVariables.blockarr[Row, column] == color)
                {
                    matches++;
                    if (matches == 4) return true;
                }
                else { break; }
            }
            /*
            ******
            ******
            ******
            *XXXP*
            ******
            ******
            ******
            */
            //nach links
            for (int count = 1; count < 4; count++)
            {
                var column = Col - count;
                if (column < GameVariables.blockarr.GetLowerBound(1) || column >= 6 || Col < 3) { break; }

                if (GameVariables.blockarr[Row, column] == color)
                {
                    matches++;
                    if (matches == 4) return true;
                }
                else { break; }
            }
            return false;
        }

        //TODO
        private bool checkdiags(int pieceRow, int pieceCol)
        {
            var colorToMatch = GameVariables.blockarr[pieceRow, pieceCol]; // Board is a ConsoleColor[7,6] array

            var matchingPieces = 1; // We will count the original piece as a match

            // Check forward slash direction '/'

            // First check down/left (decrement both row and column up to 3 times)
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow - counter;
                var col = pieceCol - counter;

                // Make sure we stay within our board
                if (row < GameVariables.blockarr.GetLowerBound(0) || col < GameVariables.blockarr.GetLowerBound(1)) { break; }

                if (GameVariables.blockarr[row, col] == colorToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return true;
                }
                else { break; }
            }

            // Next check up/right (increment both row and column up to 3 times)
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow + counter;
                var col = pieceCol + counter;

                // Make sure we stay within our board
                if (row > GameVariables.blockarr.GetUpperBound(0) || col > GameVariables.blockarr.GetUpperBound(1)) { break; }

                // Check for a match
                if (GameVariables.blockarr[row, col] == colorToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return true;
                }
                else { break; }
            }

            // If we got this far, no match was found in forward slash direction,
            // so reset our counter and check the back slash direction '\'
            matchingPieces = 1;

            // First check down/right (decrement row and increment column)
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow - counter;
                var col = pieceCol + counter;

                // Make sure we stay within our board
                if (row < GameVariables.blockarr.GetLowerBound(0) || col > GameVariables.blockarr.GetUpperBound(1)) { break; }

                // Check for a match
                if (GameVariables.blockarr[row, col] == colorToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return true;
                }
                else { break; }
            }

            // Next check up/left (increment row and decrement column)
            for (int counter = 1; counter < 4; counter++)
            {
                var row = pieceRow + counter;
                var col = pieceCol - counter;

                // Make sure we stay within our board
                if (row > GameVariables.blockarr.GetUpperBound(0) || col < GameVariables.blockarr.GetLowerBound(1)) { break; }

                // Check for a match
                if (GameVariables.blockarr[row, col] == colorToMatch)
                {
                    matchingPieces++;
                    if (matchingPieces == 4) return true;
                }
                else { break; }
            }

            // If we've gotten this far, then we haven't found a match
            return false;
        }

    }
}