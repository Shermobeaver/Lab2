using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace Lab_2
{
    // V2DataArray
    class V2DataArray : V2Data
    {
        // Array Data
        public Complex[,] Contents { get; private set; }
        public Vector2 Step { get; private set; }
        public int OxCount { get; private set; }
        public int OyCount { get; private set; }

        // Constructors
        public V2DataArray(string instr, DateTime intime) : base(instr, intime)
        {
            Complex[,] dataItems = new Complex[0, 0];
            Contents = dataItems;
        }

        public V2DataArray(string instr, DateTime intime, int inOxCount, int inOyCount, Vector2 inStep, Fv2Complex F) : base(instr, intime)
        {
            OxCount = inOxCount;
            OyCount = inOyCount;
            Complex[,] dataItems = new Complex[inOxCount, inOyCount];
            Contents = dataItems;
            Step = inStep;
            for (int i = 0; i < OxCount; i++)
            {
                for (int j = 0; j < OyCount; j++)
                {
                    Contents[i, j] = F(Step);
                }
            }
        }

        // Properties
        public override int Count
        {
            get
            {
                return OxCount * OyCount;
            }
        }

        public override float MinDistance
        {
            get
            {
                if (Step.X > Step.Y)
                {
                    return Step.Y;
                }
                else
                {
                    return Step.X;
                }
            }
        }

        // File operations
        public bool SaveBinary(string filename)
        {
            try
            {
                BinaryWriter writer = new(File.Open(filename, FileMode.Create));
                try
                {
                    writer.Write(Step.X);
                    writer.Write(Step.Y);
                    writer.Write(OxCount);
                    writer.Write(OyCount);
                    for (int i = 0; i < OxCount; i++)
                    {
                        for (int j = 0; j < OyCount; j++)
                        {
                            writer.Write(Contents[i, j].Real);
                            writer.Write(Contents[i, j].Imaginary);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error have occurred: {0}", e.Message);
                    return false;
                }
                finally
                {
                    writer.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error have occurred: {0}", e.Message);
                return false;
            }
            return true;
        }

        public bool LoadBinary(string filename, ref V2DataArray item)
        {
            try
            {
                BinaryReader reader = new(File.Open(filename, FileMode.Open));
                try
                {
                    float StepX = reader.ReadSingle();
                    float StepY = reader.ReadSingle();
                    Step = new(StepX, StepY);
                    OxCount = reader.ReadInt32();
                    OyCount = reader.ReadInt32();
                    Vector2 vector = new(StepX, StepY);
                    item = new(item.Str, item.DateAndTime, OxCount, OyCount, vector, FuncV2Complex.FuncV2Complex_1);
                    for (int i = 0; i < OxCount; i++)
                    {
                        for (int j = 0; j < OyCount; j++)
                        {
                            double ContentsRe = reader.ReadDouble();
                            double ContentsIm = reader.ReadDouble();
                            item.Contents[i, j] = new(ContentsRe, ContentsIm);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error have occurred: {0}", e.Message);
                    return false;
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error have occurred: {0}", e.Message);
                return false;
            }
            return true;
        }

        // IEnumerable
        override public IEnumerator<DataItem> GetEnumerator()
        {
            return (IEnumerator<DataItem>) new V2DataArrayIEnumerator(this);
        }

        // Output
        override public string ToLongString(string format)
        {
            string output = string.Format($"Type: V2DataArray, Characteristics: {Str},  Date/Time: {DateAndTime}, Step: {Step.ToString((format))}, Ox: {OxCount}, Oy: {OyCount}\n");
            for (int i = 0; i < OxCount; i++)
            {
                for (int j = 0; j < OyCount; j++)
                {
                    output += string.Format($"DataItem Contents: Coords: {i * Step.X} {j * Step.Y},  Value: {Contents[i, j].ToString((format))}, Module: {(Contents[i, j].Magnitude).ToString((format))}\n");
                }
            }
            return output;
        }

        override public string ToString()
        {
            return string.Format($"Type: V2DataArray, Characteristics: {Str},  Date/Time: {DateAndTime}, Step: {Step}, Ox: {OxCount}, Oy: {OyCount}\n");
        }

        // Converter
        public static implicit operator V2DataList(V2DataArray Old)
        {
            V2DataList newlist = new("List From" + Old.Str, DateTime.Now);
            for (int i = 0; i < Old.OxCount; i++)
            {
                for (int j = 0; j < Old.OyCount; j++)
                {
                    System.Numerics.Vector2 vector_1 = new(i * Old.Step.X, j * Old.Step.Y);
                    DataItem item1 = new(vector_1, Old.Contents[i, j]);
                    newlist.Add(item1);
                }
            }
            return newlist;
        }
    }


    // V2DataArray IEnumerator
    class V2DataArrayIEnumerator : IEnumerator<DataItem>
    {
        private int currentX;
        private int currentY;
        private V2DataArray reference;
        private DataItem CurItem;

        public V2DataArrayIEnumerator(V2DataArray inref)
        {
            currentX = 0;
            currentY = -1;
            reference = inref;
        }

        public DataItem Current
        {
            get
            {
                return CurItem;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return CurItem;
            }
        }

        public bool MoveNext()
        {
            if ((reference.OxCount == 0) || (reference.OyCount == 0))
            {
                return false;
            }
            currentY++;
            if (currentY < reference.OyCount)
            {
                Vector2 vector = new(currentX * reference.Step.X, currentY * reference.Step.Y);
                CurItem = new(vector, reference.Contents[currentX, currentY]);
                return true;
            }
            else
            {
                currentX++;
                if (currentX < reference.OxCount)
                {
                    currentY = 0;
                    Vector2 vector = new(currentX * reference.Step.X, currentY * reference.Step.Y);
                    CurItem = new(vector, reference.Contents[currentX, currentY]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Reset()
        {
            currentX = 0;
            currentY = -1;
        }

        void IDisposable.Dispose() { }
    }
}
