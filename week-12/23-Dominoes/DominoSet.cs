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
                    if (Dominos[i].Value[0] > Dominos[i].Value[1]) Dominos[i] = Dominos[i].Rotate();
                }
            }

            Dominos.Sort();
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
