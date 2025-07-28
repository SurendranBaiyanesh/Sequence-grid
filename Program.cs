using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GridCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            char[][] cInputArray1 = new char[][]
            {
              new [] {'A','B','C','E'},
              new [] {'S','F','C','S'},
              new [] {'A','D','E','E'}
            };

            Console.WriteLine(program.IsSequenceGrid("ABCCED", cInputArray1));


            char[][] cInputArray2 = new char[][]
            {
                new [] {'B','C','A'},
                new [] {'S','M','C'},
                new [] {'T','S','E'}
            };

            Console.WriteLine(program.IsSequenceGrid("BSTSE", cInputArray2));


            char[][] cInputArray3 = new char[][]
            {
                new [] {'T','C','A'},
                new [] {'S','K','C'},
                new [] {'T','S','E'}
            };

            Console.WriteLine(program.IsSequenceGrid("BSTSE", cInputArray3));


            char[][] cInputArray4 = new char[][]
            {
                new [] {'S','S','S'},
                new [] {'S','S','C'},
                new [] {'T','S','E'}
            };

            Console.WriteLine(program.IsSequenceGrid("SSST", cInputArray4));

            Console.ReadKey();
        }

        private bool IsSequenceGrid(string strInput, char[][] cInputArray)
        {
            int nNestedArrayLength = cInputArray[0].Length;

            List<char> liCharacter = cInputArray.SelectMany(row => row).ToList();

            int nIndex = liCharacter.IndexOf(strInput[0]);
            if (nIndex < 0) return false;

            return SequenceGrid(0, 0, strInput, liCharacter, nNestedArrayLength);
        }

        private bool SequenceGrid(int nIndex ,int nLastCharacterIndex, string strInput, List<char> liCharacter, int nNestedArrayLength)
        {
            if (nIndex + 1 == strInput.Length) return true;

            char cSiblingCharacter = strInput[nIndex + 1];

            int nRightSiblingIndex = nLastCharacterIndex + 1;
            int nBottomSiblingIndex = nLastCharacterIndex + nNestedArrayLength;
            int nLeftSiblingIndex = nLastCharacterIndex - 1;
            int nTopSiblingIndex = nLastCharacterIndex - nNestedArrayLength;

            if(nRightSiblingIndex < liCharacter.Count && cSiblingCharacter == liCharacter.ElementAt(nRightSiblingIndex))
            {
                SequenceGrid(nIndex + 1, nRightSiblingIndex, strInput, liCharacter, nNestedArrayLength);
            }
            else if(nBottomSiblingIndex < liCharacter.Count && cSiblingCharacter == liCharacter.ElementAt(nBottomSiblingIndex))
            {
                SequenceGrid(nIndex + 1, nBottomSiblingIndex, strInput, liCharacter, nNestedArrayLength);
            } 
            else if(nLeftSiblingIndex > 0 && cSiblingCharacter == liCharacter.ElementAt(nLeftSiblingIndex)) 
            {
                SequenceGrid(nIndex + 1, nLeftSiblingIndex, strInput, liCharacter, nNestedArrayLength);
            }
            else if(nTopSiblingIndex > 0 && cSiblingCharacter == liCharacter.ElementAt(nTopSiblingIndex))
            {
                SequenceGrid(nIndex + 1, nTopSiblingIndex, strInput, liCharacter, nNestedArrayLength);
            }
            else return false;

            return true;
        }
    }
}
