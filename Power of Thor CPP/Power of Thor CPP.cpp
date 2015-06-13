#include "stdafx.h"

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor does not follow your orders.
 **/
int main()
{
    int LX; // the X position of the light of power
    int LY; // the Y position of the light of power
    int thorX; // Thor's starting X position
    int thorY; // Thor's starting Y position
    cin >> LX >> LY >> thorX >> thorY; 
	cin.ignore();

    // game loop
    while (1) {
        int E; // The level of Thor's remaining energy, representing the number of moves he can still make.
        cin >> E; 
		cin.ignore();

        // Write an action using cout. DON'T FORGET THE "<< endl"
        // To debug: cerr << "Debug messages..." << endl;
		if (thorY > LY) {
			thorY--;
			cout << 'N';
		} else if (thorY < LY) {
			thorY++;
			cout << 'S';
		}

		if (thorX > LX) {
			thorX--;
			cout << 'W';
		} else if (thorX < LX) {
			thorX++;
			cout << 'E';
		}

		cout << endl;
    }
}
