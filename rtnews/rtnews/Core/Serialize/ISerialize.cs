using System;
using System.Collections.Generic;

namespace rtnews
{
    public interface ISerialize
    {
        void RunNumber(ref sbyte nValue, string nName);
        void RunNumbers(ref sbyte nValue, string nName);
        void RunNumber(ICollection<sbyte> nValue, string nNames, string nName);
		void RunNumberCount(ref sbyte nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<sbyte> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<sbyte> nValue, string nName);

        void RunNumber(ref byte nValue, string nName);
        void RunNumbers(ref byte nValue, string nName);
        void RunNumber(ICollection<byte> nValue, string nNames, string nName);
        void RunNumberCount(ref byte nValue, string nName, sbyte nCount);
        void RunNumberCount(ICollection<byte> nValue, string nName, sbyte nCount);
        void RunNumberSemi(ICollection<byte> nValue, string nName);

        void RunNumber(ref short nValue, string nName);
        void RunNumbers(ref short nValue, string nName);
        void RunNumber(ICollection<short> nValue, string nNames, string nName);
		void RunNumberCount(ref short nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<short> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<short> nValue, string nName);

        void RunNumber(ref ushort nValue, string nName);
        void RunNumbers(ref ushort nValue, string nName);
        void RunNumber(ICollection<ushort> nValue, string nNames, string nName);
        void RunNumberCount(ref ushort nValue, string nName, sbyte nCount);
        void RunNumberCount(ICollection<ushort> nValue, string nName, sbyte nCount);
        void RunNumberSemi(ICollection<ushort> nValue, string nName);

        void RunNumber(ref int nValue, string nName);
        void RunNumbers(ref int nValue, string nName);
        void RunNumber(ICollection<int> nValue, string nNames, string nName);
		void RunNumberCount(ref int nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<int> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<int> nValue, string nName);

        void RunNumber(ref uint nValue, string nName);
        void RunNumbers(ref uint nValue, string nName);
        void RunNumber(ICollection<uint> nValue, string nNames, string nName);
        void RunNumberCount(ref uint nValue, string nName, sbyte nCount);
        void RunNumberCount(ICollection<uint> nValue, string nName, sbyte nCount);
        void RunNumberSemi(ICollection<uint> nValue, string nName);

        void RunNumber(ref long nValue, string nName);
        void RunNumbers(ref long nValue, string nName);
        void RunNumber(ICollection<long> nValue, string nNames, string nName);
		void RunNumberCount(ref long nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<long> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<long> nValue, string nName);

        void RunNumber(ref ulong nValue, string nName);
        void RunNumbers(ref ulong nValue, string nName);
        void RunNumber(ICollection<ulong> nValue, string nNames, string nName);
        void RunNumberCount(ref ulong nValue, string nName, sbyte nCount);
        void RunNumberCount(ICollection<ulong> nValue, string nName, sbyte nCount);
        void RunNumberSemi(ICollection<ulong> nValue, string nName);

        void RunNumber(ref float nValue, string nName);
        void RunNumbers(ref float nValue, string nName);
        void RunNumber(ICollection<float> nValue, string nNames, string nName);
		void RunNumberCount(ref float nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<float> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<float> nValue, string nName);

		void RunNumber(ref double nValue, string nName);
        void RunNumbers(ref double nValue, string nName);
        void RunNumber(ICollection<double> nValue, string nNames, string nName);
		void RunNumberCount(ref double nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<double> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<double> nValue, string nName);

		void RunNumber(ref string nValue, string nName);
        void RunNumbers(ref string nValue, string nName);
        void RunNumber(ICollection<string> nValue, string nNames, string nName);
		void RunNumberCount(ref string nValue, string nName, sbyte nCount);
		void RunNumberCount(ICollection<string> nValue, string nName, sbyte nCount);
		void RunNumberSemi(ICollection<string> nValue, string nName);

        void RunCrc32(ref uint nValue, string nName);
		void RunCrc32(ICollection<uint> nValue, string nNames, string nName);
        void RunCrc32Count(ref uint nValue, string nName, sbyte nCount);
        void RunCrc32Count(ICollection<uint> nValue, string nName, sbyte nCount);
        void RunCrc32Semi(ICollection<uint> nValue, string nName);

        void RunTime(ref ulong nValue, string nName);
        void RunTimes(ref ulong nValue, string nName);
        void RunTime(ICollection<ulong> nValue, string nNames, string nName);
        void RunTimeCount(ref ulong nValue, string nName, sbyte nCount);
        void RunTimeCount(ICollection<ulong> nValue, string nName, sbyte nCount);
        void RunTimeSemi(ICollection<ulong> nValue, string nName);

        void RunBuffer(ref byte[] nValue, ref short nLength);

        void RunStream<T>(T nValue, string nName) where T : IStream, new();
		void RunStream<T>(ICollection<T> nValue, string nNames, string nName) where T : IStream, new();
		void RunStream<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName) where T1 : IMapStream, new();
		void RunStreamCount<T>(T nValue, string nName, sbyte nCount) where T : IStream, new();
        void RunStreamCount<T>(ICollection<T> nValue, string nNames, string nName, sbyte nCount) where T : IStream, new();
        void RunStreamCount<T0, T1>(IDictionary<T0, T1> nValue, string nNames, string nName, sbyte nCount) where T1 : IMapStream, new();

        void PushStream(string nName);
        void PopStream(string nName);

        void PushClass(string nName);
        void PopClass(string nName);

        void PushArray(string nName);
        bool RunChild(string nName);
        bool RunNext(string nName);
        void PopArray(string nName);

        bool IsText();
    }
}
