namespace _4gewinnt
{
    class GameLogic
    {

        //Ходим по полю и проверяем, выиграна игра или нет

        public static bool check(int Col, int Row, byte[,] blockarr)
        {
            /*
            Row & Col = Der gesetzte punkt
            row & col = Der nächste punkt, der von dem algo geprüft wird
            */
            var matches = 1;
            var row = Row;
            var col = Col;

            for (int round = 2; round < 9; round++)
            {
                //Matches zurücksetzen
                switch (round) {
                    case 3:
                    case 5:
                    case 7:
                        matches = 1;
                        break;
                }
                for (int count = 1; count < 4; count++)
                {
                    switch (round)
                    {
                        case 1: //vertikal hoch *wird nicht benötigt*
                            row = Row - count;
                            break;
                        case 2: //vertikal runter
                            row = Row + count;
                            break;
                        case 3: //horizontal rechts
                            col = Col + count;
                            break;
                        case 4: //horizontal links
                            col = Col - count;
                            break;
                        case 5: // \ hoch
                            row = Row - count;
                            col = Col - count;
                            break;
                        case 6: // \ runter
                            row = Row + count;
                            col = Col + count;
                            break;
                        case 7: // / hoch
                            row = Row - count;
                            col = Col + count;
                            break;
                        case 8:// / runter
                            row = Row + count;
                            col = Col - count;
                            break;
                    }
                    // 0: col 1: row

                    /*
                    Sind wir im erlaubten Bereich? 
                    Nein -> end
                    Ja   -> farbe richtig?
                            Ja -> match +1
                                    match = 4? -> return true
                            Nein -> aus dem for loop springen, da wir keine 4 gleichen farben nacheinander haben
                    */
                    switch (round)
                    {
                        case 1:
                        case 2:
                            col = Col;
                            if (row < blockarr.GetLowerBound(1) || row > blockarr.GetUpperBound(1)) { goto end; }
                            break;
                        case 3:
                        case 4:
                            row = Row;
                            if (col < blockarr.GetLowerBound(0) || col > blockarr.GetUpperBound(0)) { goto end; }
                            break;
                        case 5:
                            if (row < blockarr.GetLowerBound(1) || col < blockarr.GetLowerBound(0)) goto end;
                            break;
                        case 6:
                            if (row > blockarr.GetUpperBound(1) || col > blockarr.GetUpperBound(0)) goto end;
                            break;
                        case 7:
                            if (row < blockarr.GetLowerBound(1) || col > blockarr.GetUpperBound(0)) goto end;
                            break;
                        case 8:
                            if (row > blockarr.GetUpperBound(1) || col < blockarr.GetLowerBound(0)) goto end;
                            break;
                    }
                    if (blockarr[col,row] == blockarr[Col, Row])
                    {
                        matches++;
                        if (matches == 4) return true;
                    }
                    else {goto bf;}
                    // Label um die if abfrage zu überspringen
                    end: ;
                }
                // Label um aus dem for loop zu springen, da das nächste feld nicht die farbe die gesucht ist hat.
                bf: ;
            }

            // keine 4 blöcke gefunden die die gleiche farbe haben :(
            return false;
        }
    }
}