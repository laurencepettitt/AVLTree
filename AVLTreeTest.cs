using System;
using System.Collections.Generic;
//using System.Diagnostics;
using static System.Diagnostics.Debug;

static class AVLTreeTest {
  static public void TestPassEpilogue() {
    ConsoleColor originalForegroundColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    WriteLine("PASS");
    Console.ForegroundColor = originalForegroundColor;
  }
  
  static public void NumberOfValuesInsertedEqualsNumberOfValuesDeleted() {
    WriteLine("TEST: AVLTreeTest.NumberOfValuesInsertedEqualsNumberOfValuesDeleted");
    Indent();
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
    
    int count = 0;
    foreach (int i in l) {
      count += t.Contains(i) ? 1 : 0;
    }
    
    Assert(count == l.Count, $"Contains method found {count} values in a list of {l.Count} (non-unique) values, which were all inserted.");
    
    int deleted = 0;
    foreach (int i in l) 
      deleted += t.Delete(i) ? 1 : 0;
            
    Assert(inserted == deleted, $"Number of values inserted ({inserted}) does not equal number of values deleted ({deleted}).");
    
    // this test may report false positives in the case that the (generic type T) values stored in the tree are null or whitespace.
    Assert(string.IsNullOrWhiteSpace(t.ToString()), "Tree not empty after deleting all values.");
    Unindent(); 
  }
  
  static public void GeneralRotationTestCase(
    string testCaseName,
    int[] valuesBeforeRotation,
    int valueWhichCausesRotation,
    string expectedBeforeRotation,
    string expectedAfterRotation)
  {
    AVLTree<int> t = new AVLTree<int>();
    Array.ForEach(valuesBeforeRotation, val => t.Insert(val));
    string actualBeforeRotation = t.ToString();
    WriteLine($"TEST: AVLTreeTest.{testCaseName}");
    Assert(expectedBeforeRotation == actualBeforeRotation, "Unexpected textual representation.",
    $@"The textual representation of the Tree has been changed since this test was written.
    Please update this test to agree with the format of the ToString method.
    Expected representation:
{expectedBeforeRotation}
    Actual representation:
{actualBeforeRotation}");
    Indent();
    //WriteLine(t);
    // right rotation after next insert..
    t.Insert(valueWhichCausesRotation);
    //WriteLine(t);
    string actualAfterRotation = t.ToString();
    Assert(expectedAfterRotation == actualAfterRotation, "The class did not perform rotation correctly.",
    $@"Expected result after rotation:
{expectedAfterRotation}
    Actual result after rotation:
{actualAfterRotation}");
    Unindent(); 
  }

  static public void LeftLeft() {
    string testCaseName = "LeftLeft";
    int[] valuesBeforeRotation = {15, 6, 20, 4, 10, 16, 2, 12, 9, 5};
    int valueWhichCausesRotation = 1;
    string expectedBeforeRotation = @"  20
    16
15
      12
    10
      9
  6
      5
    4
      2
";
    string expectedAfterRotation = @"    20
      16
  15
      12
    10
      9
6
    5
  4
    2
      1
";
    GeneralRotationTestCase(
      testCaseName,
      valuesBeforeRotation,
      valueWhichCausesRotation,
      expectedBeforeRotation,
      expectedAfterRotation
    );
  }
  // tests double rotation (left, then right) 
  static public void LeftRight() {
    string testCaseName = "LeftRight";
    int[] valuesBeforeRotation = {15, 6, 20, 4, 10, 16, 2, 12, 9, 5};
    int valueWhichCausesRotation = 8;
    string expectedBeforeRotation = @"  20
    16
15
      12
    10
      9
  6
      5
    4
      2
";
    string expectedAfterRotation = @"    20
      16
  15
    12
10
    9
      8
  6
      5
    4
      2
";
    GeneralRotationTestCase(
      testCaseName,
      valuesBeforeRotation,
      valueWhichCausesRotation,
      expectedBeforeRotation,
      expectedAfterRotation
    );
  }
  
  static public void RightRight() {
    string testCaseName = "RightRight";
    int[] valuesBeforeRotation = {15, 6, 20, 10, 17, 25, 16, 18, 22, 27};
    int valueWhichCausesRotation = 26;
    string expectedBeforeRotation = @"      27
    25
      22
  20
      18
    17
      16
15
    10
  6
";
    string expectedAfterRotation = @"    27
      26
  25
    22
20
      18
    17
      16
  15
      10
    6
";
    GeneralRotationTestCase(
      testCaseName,
      valuesBeforeRotation,
      valueWhichCausesRotation,
      expectedBeforeRotation,
      expectedAfterRotation
    );
  }
  // tests double rotation (right, then left)
  static public void RightLeft() {
    string testCaseName = "RightLeft";
    int[] valuesBeforeRotation = {15, 6, 20, 10, 17, 25, 16, 18, 22, 27};
    int valueWhichCausesRotation = 19;
    string expectedBeforeRotation = @"      27
    25
      22
  20
      18
    17
      16
15
    10
  6
";
    string expectedAfterRotation = @"      27
    25
      22
  20
      19
    18
17
    16
  15
      10
    6
";
    GeneralRotationTestCase(
      testCaseName,
      valuesBeforeRotation,
      valueWhichCausesRotation,
      expectedBeforeRotation,
      expectedAfterRotation
    );
  }
  
  static void Main() {
    AVLTreeTest.NumberOfValuesInsertedEqualsNumberOfValuesDeleted();
    AVLTreeTest.LeftLeft();
    AVLTreeTest.LeftRight();
    AVLTreeTest.RightRight();
    AVLTreeTest.RightLeft();
  }
}
