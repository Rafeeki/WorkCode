#include <iostream>

using namespace std;

int main()
{
	int row, col;
	cout << "Enter # of rows: ";
	cin >> row;
	cout << "Enter # of columns: ";
	cin >> col;
	cout << row << " rows & " << col << " columns coming up!\n";
	int table[row][col];
	//table[0][0] = 1;
	//table[0][1] = 2;
	//cout << table[0][0] << "\t" << table[0][1] << endl; 
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			table[i][j] = (i+1) * (j+1);
			cout << table[i][j] << "\t";
		}
		cout << endl;
	}
	delete[] table;	
}
