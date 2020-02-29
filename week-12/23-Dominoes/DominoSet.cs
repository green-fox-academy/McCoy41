using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _23_Dominoes
{
    class DominoSet : IList<Domino>
    {
        // Required for IList<Domino>
        public int Count => Dominos.Count;
        public bool IsReadOnly => false;
        public Domino this[int index] { get => Dominos[index]; set => throw new NotImplementedException(); }


        public List<Domino> Dominos { get; private set; } = new List<Domino>();

        public DominoSet(bool random = true, int count = 0)
        {
            if (!random) // from syllabus
            {
                Dominos.Add(new Domino(5, 2));
                Dominos.Add(new Domino(4, 6));
                Dominos.Add(new Domino(1, 5));
                Dominos.Add(new Domino(6, 7));
                Dominos.Add(new Domino(2, 4));
                Dominos.Add(new Domino(7, 1));
            }
            else
            {
                if (count <= 1 || count > DefaultValues.maxCount) count = Randomizer.RndCount();

                for (int i = 0; i < count; i++)
                {
                    Dominos.Add(new Domino());
                }
            }
        }

        public DominoSet(int count)
            : this(true, count)
        { }

        public DominoSet(List<Domino> dominos)
        {
            Dominos = dominos;
        }

        public DominoSet(DominoSet dominos)
            : this(dominos.Dominos)
        { }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < Dominos.Count; i++)
            {
                if (i != 0) output += (i % 10 == 0) ? "\n" : " ";
                output += Dominos[i].ToString();
            }

            return output;
        }

        public void Sort(bool rotate = false)
        {
            if (rotate)
            {
                for (int i = 0; i < Dominos.Count; i++)
                {
                    if (Dominos[i].Value[0] > Dominos[i].Value[1])
                    {
                        Dominos[i] = Dominos[i].Rotate();
                    }
                }
            }

            Dominos.Sort();
        }

        public void ChainDominos(out DominoSet connected, out DominoSet extra)
        {
            List<Domino> dominosIn = Dominos;
            List<Domino> dominosOut = new List<Domino>(Dominos.Count);
            int first = GetFirstPiece();
            dominosOut.Add(RotateFirstPiece() ? dominosIn[first].Rotate() : dominosIn[first]);
            dominosIn.RemoveAt(first);

            bool matchFound;
            do
            {
                matchFound = false;
                for (int i = 0; i < dominosIn.Count; i++)
                {
                    if (dominosOut[dominosOut.Count - 1].Value[1] == dominosIn[i].Value[0])
                    {
                        dominosOut.Add(dominosIn[i]);
                        dominosIn.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                    if (dominosOut[dominosOut.Count - 1].Value[1] == dominosIn[i].Value[1])
                    {
                        dominosOut.Add(dominosIn[i].Rotate());
                        dominosIn.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                }
            } while (matchFound);

            connected = new DominoSet(dominosOut);
            extra = new DominoSet(dominosIn);
            extra.Sort(true);
        }

        int GetFirstPiece()
        {
            int index;
            Console.Write("Please specify first piece: ");
            try
            {
                index = Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Input couldn't be converted to a number!");
                index = 1;
            }

            if (index - 1 < 0 || index - 1 >= Dominos.Count) index = 1;
            return index - 1;
        }

        bool RotateFirstPiece()
        {
            Console.WriteLine("Would you like to rotate the first piece? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) return true;
            else return false;
        }
        


        // Required for IList<Domino>
        public int IndexOf(Domino item)
        {
            return Dominos.IndexOf(item);
        }

        public void Insert(int index, Domino item)
        {
            Dominos.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Dominos.RemoveAt(index);
        }

        public void Add(Domino item)
        {
            Dominos.Add(item);
        }

        public void Clear()
        {
            Dominos.Clear();
        }

        public bool Contains(Domino item)
        {
            return Dominos.Contains(item);
        }

        public void CopyTo(Domino[] array, int arrayIndex)
        {
            Dominos.CopyTo(array, arrayIndex);
        }

        public bool Remove(Domino item)
        {
            return Dominos.Remove(item);
        }

        public IEnumerator<Domino> GetEnumerator()
        {
            return Dominos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Dominos.GetEnumerator();
        }
    }
}
