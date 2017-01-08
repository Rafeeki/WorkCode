#include <iostream>
#include <string>

using namespace std;

int main()
{
	/* Pointer-to-pointer intro
	int **p_p_x;
	int *p_y;
	cout << "Orig p_p_x Loc: " << &p_p_x << " & orig p_p_x Val: " << p_p_x << endl;
	cout << "Orig p_y Loc: " << &p_y << " & orig p_y Val: " << endl;
	p_p_x = &p_y;
	cout << "New p_p_x Val: " << p_p_x << endl;
	delete p_p_x;
	delete p_y;
	*/
	/* Tic-tac-toe board with pointers
	int **p_p_tictactoe;
	p_p_tictactoe = new int*[3];
	for (int i = 0; i < 3; i++)
	{
		p_p_tictactoe[i] = new int[3];
	}
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			p_p_tictactoe[i][j] = 0;
		}
	}
	for (int k = 0; k < 9; k++)
	{
		if (k % 3 == 0)
			cout << endl;
		cout << p_p_tictactoe[k] << "\t";
		
	}
	cout << endl;
	for (int i = 0; i < 3; i++)
	{
		delete [] p_p_tictactoe[i];
	}
	delete [] p_p_tictactoe;
	cout << "p_p_tictactoe deleted!" << endl;
	*/
	int x = 0;
	int *p_int = &x;
	int **p_p_int = &p_int;
	*p_int = 12;
	**p_p_int = 25;
	p_int = 12;
	cout << "x Loc: " << &x << ", x Val: " << x << endl;
	cout << "p_int Loc: " << &p_int << ", p_int Val: " << p_int << endl;
	cout << "p_p_int Loc: " << &p_p_int << ", p_p_int Val: " << p_p_int << endl;
}
