using System;
//using static System.Console;
using System.Collections.Generic;
//using System.Diagnostics;
using static System.Diagnostics.Debug;

static class AVLTreeTests {
  static public void NumberOfValuesInsertedEqualsNumberOfValuesDeleted() {
    Random rand = new Random();
    AVLTree<int> t = new AVLTree<int>();
    List<int> l = new List<int>();
    int inserted = 0;
    for (int i = 0 ; i < 100 ; ++i) {
      int r = rand.Next(1000);
      inserted += t.Insert(r) ? 1 : 0;
      l.Add(r);
    }
    
    Assert(inserted == t.Count, $"Number of values inserted ({inserted}) does not equal internal Count ({t.Count}).");
    
    WriteLine("l.Count: " + l.Count);
    
    int count = 0;
    foreach (int i in l) {
      count += t.Contains(i) ? 1 : 0;
    }
    WriteLine("contains count: " + count);
    
    Assert(count == l.Count, $"Contains method found {count} values in a list of {l.Count} (non-unique) values, which were all inserted.");
    
    int deleted = 0;
    foreach (int i in l) 
      deleted += t.Delete(i) ? 1 : 0;
      
    Assert(inserted == t.Count, $"Number of values inserted ({inserted}) does not equal number of values deleted ({deleted}).");
    
    // this test may report false positives in the case that the (generic type T) values stored in the tree are null or whitespace.
    Assert(string.IsNullOrWhiteSpace(t.ToString()), "Tree not empty after deleting all values.");
  }
  
  // tests single right rotation
  static public void LeftLeft() {
    AVLTree<int> t = new AVLTree<int>();
    t.Insert(15);
    t.Insert(6);
    t.Insert(20);
    t.Insert(4);
    t.Insert(10);
    t.Insert(16);
    t.Insert(2);
    t.Insert(12);
    t.Insert(9);
    t.Insert(5);
    WriteLine(t);
    // right rotation after next insert..
    t.Insert(1);
    WriteLine(t);
  }
  // tests double rotation (left, then right) 
  static public void LeftRight() {
    AVLTree<int> t = new AVLTree<int>();
    
  }
  // tests single left rotation
  static public void RightRight() {
    AVLTree<int> t = new AVLTree<int>();
    t.Insert(0);
    t.Insert(2);
    t.Insert(-2);
    t.Insert(-1);
    t.Insert(3);
    t.Insert(-3);
    WriteLine(t);
    // left rotation after next insert..
    t.Insert(4);
    WriteLine(t);
  }
  // tests double rotation (right, then left)
  static public void RightLeft() {
    AVLTree<int> t = new AVLTree<int>();
    
  }
  
  static void Main() {
    AVLTreeTests.NumberOfValuesInsertedEqualsNumberOfValuesDeleted();
    //AVLTreeTests.LeftLeft();
    //AVLTreeTests.RightRight();
  }
}
