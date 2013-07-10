#include <iostream>
#include <string.h>
using namespace std;

int main () {
  int n = 5;
  int k = 2;
  
  for (int i=1; i<=n; i++)
  {
      for (int j=1; j<= n; j++)
      {   
          if (i != j && j>i )
          {
                cout<< i << " " <<j<< endl;    
                }
      }    
  }
      
          
    system("PAUSE");
    return EXIT_SUCCESS;
}
