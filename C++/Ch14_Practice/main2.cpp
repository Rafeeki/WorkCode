#include <iostream>

using namespace std;

int main()
{
	int len, wid, ht;
	cout << "Enter length: ";
	cin >> len;
	cout << "Enter width: ";
	cin >> wid;
	cout << "Enter height: ";
	cin >> ht;
	cout << len << "x" << wid << "x" << ht << " matrix coming up!\n";
	int table[len][wid][ht];
	//table[0][0] = 1;
	//table[0][1] = 2;
	//cout << table[0][0] << "\t" << table[0][1] << endl; 
	
	for (int i = 0; i < len; i++)
	{
		for (int j = 0; j < wid; j++)
		{
			for (int k = 0; k < ht; k++)
			{
				table[i][j][k] = (i+1) * (j+1) * (k+1);
				cout << table[i][j][k] << "\t";
			}
			cout << endl;
		}
		cout << endl;
	}
	delete[] table;	
}
