using System;
using static System.Console;
using static System.Math;

public class fit{
	public vector c;
	public Func<double, double>[] funcs;
	public matrix cov;
	public fit(vector c, Func<double, double>[] funcs, matrix cov){
		this.c = c;
		this.funcs = funcs;
		this.cov = cov;
	}

	public double eval(double x){
		double result = 0;
		for(int i = 0; i < funcs.Length; i++){
			result += c[i] * funcs[i](x);
		}
		return result;
	}

	public vector getParamErrors(){
		double[] errors = new double[c.size];
		for(int k = 0; k < c.size; k++){
			errors[k] = Sqrt(cov[k, k]);
		}
		return errors;
		}

}
