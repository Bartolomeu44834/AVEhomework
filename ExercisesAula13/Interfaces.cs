
namespace Interfaces {
    public interface IEquality {
        bool AreEqual(object x, object y);
    }

    public interface IComparer { 
        int Compare(object x, object y); 
    }
}