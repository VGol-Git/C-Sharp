#pragma once
#include "pch.h"
#include <math.h>
#include <time.h>

class Matrix
{
private:
	double* mass;
	int size = 0;

	static double Scb(double** b, double** c, int k0, int n, int i, int j)
	{
		double sum = 0;
		for (int k = k0; k <= n; k++)
			sum += b[i][k] * c[k][j - k];

		return sum;
	}

public:
	Matrix(int n)
	{
		size = n;
		mass = new double[size];
		*mass = 16;
		for (int i = 1; i < size; i++)
			* (mass + i) = 1;
	}
	Matrix(double* vector, int s)
	{
		size = s;
		mass = new double[size];
		for (int i = 0; i < size; i++)
			* (mass + i) = *(vector + i);

	}
	Matrix(const Matrix& ptr)
	{
		this->size = ptr.size;
		mass = new double[size];
		for (int i = 0; i < size; i++)
			this->mass = ptr.mass;
	}
	~Matrix()
	{
		delete mass;
	}
	Matrix operator=(const Matrix& ptr)
	{
		this->size = ptr.size;
		for (int i = 0; i < size; i++)
			this->mass = ptr.mass;
	}

	double* solve(double* solution)
	{
		double** b = new double* [size];
		for (int i = 1; i <= size; i++)
			b[i - 1] = new double[i];

		double** c = new double* [size];
		for (int i = size; i > 0; i--)
			c[size - i] = new double[i];


		for (int k = 0; k < size; k++)
		{
			b[k][0] = mass[k];
			c[0][k] = mass[k] / mass[0];
		}

		for (int i = 1; i < size; i++)
		{
			for (int j = 1; j < size; j++)
			{
				if (i >= j)
					b[i][j] = mass[abs(i - j)] - Scb(b, c, 0, j - 1, i, j);
				if (i <= j)
					c[i][j - i] = (mass[abs(i - j)] - Scb(b, c, 0, i - 1, i, j)) / b[i][i];
			}
		}

		double* y = new double[size];
		double* x = new double[size];

		y[0] = solution[0] / b[0][0];
		for (int i = 1; i < size; i++)
		{
			double sum = 0;
			for (int k = 0; k <= i - 1; k++)
				sum += b[i][k] * y[k];
			y[i] = (solution[i] - sum) / b[i][i];
		}

		x[size - 1] = y[size - 1];
		for (int i = size - 2; i >= 0; i--)
		{
			double sum = 0;
			for (int k = i + 1; k < size; k++)
				sum += x[k] * c[i][k - i];
			x[i] = y[i] - sum;
		}
		for (int i = 0; i < size; i++)
			delete* (b + i);
		delete[] b;

		for (int i = 0; i < size; i++)
			delete* (c + i);
		delete[] c;
		delete[] y;


		return x;
	}
};
// Конец Matrix


extern "C" __declspec(dllexport) double _cdecl Timer(int size, int times)
{
	Matrix* A = new Matrix(size);
	double* vector = new double[size];
	for (int i = 0; i < size; i++)
		* (vector + i) = (double)i;

	clock_t t = clock();
	for (int i = 0; i < times; i++)
		A->solve(vector);
	t = clock() - t;
	return (((double)t) / CLOCKS_PER_SEC);
}

extern "C" __declspec(dllexport) void _cdecl solve(double* init_vector, double* solve_vector, int size, double* Ans)
{
	Matrix* A = new Matrix(init_vector, size);
	double* vector = new double[size];
	double* solution = A->solve(solve_vector);
	for (int i = 0; i < size; i++)
		Ans[i] = solution[i];
}



