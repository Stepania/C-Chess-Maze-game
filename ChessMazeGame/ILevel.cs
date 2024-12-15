using System;
using System.Collections.Generic;
using System.Text;
using FilerNS;

namespace Maze
{
	public interface ILevel
	{
		void CreateLevel(int width, int height);
		void SetLevelName(string value);
		string GetLevelName();
		void SetLevelWidth(int width);
		void SetLevelHeight(int height);
		int GetLevelWidth();
		int GetLevelHeight();
		void AddEmpty(int gridX, int gridY);
		void AddKing(int gridX, int gridY);
		void AddRook(int gridX, int gridY);
		void AddBishop(int gridX, int gridY);
		void AddKnight(int gridX, int gridY);
		void AddPlayerOnEmpty(int gridX, int gridY);
		void AddPlayerOnKing(int gridX, int gridY);
		void AddPlayerOnRook(int gridX, int gridY);
		void AddPlayerOnBishop(int gridX, int gridY);
		void AddPlayerOnKnight(int gridX, int gridY);
		Part GetPartAtIndex(int gridX, int gridY);
/*		void SaveMe();
		void LoadMe();*/
		bool CheckValid();
	}
}

