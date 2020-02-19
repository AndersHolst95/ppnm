using System;
using static System.Console;
using static System.Math;

public struct vector3d : ivector3d{
	public double x{get; set;}
	public double y{get; set;}
	public double z{get; set;}

	
	public vector3d(double x, double y, double z){
	this.x = x;
	this.y = y;
	this.z = z;
	}

	public override string ToString(){
	return $"({x}, {y}, {z})";
	}

	public static vector3d operator+(vector3d v, vector3d u){
	return new vector3d(v.x+u.x, v.y+u.y, v.z+u.z);
	}

	public static vector3d operator-(vector3d v, vector3d u){
	return new vector3d (v.x-u.x, v.y-u.y, v.z-u.z);
	}
	
	public static vector3d operator*(vector3d v, double c){
	return new vector3d(c*v.x, c*v.y, c*v.z);
	}
	
	public static vector3d operator*(double c, vector3d v){
	return new vector3d(c*v.x,c*v.y,c*v.z);
	}
	
	public static vector3d operator/(vector3d v, double c){
	return new vector3d(v.x/c, v.y/c, v.z/c);
	}
	
	public double dot_product(ivector3d v){
	return x*v.x + y*v.y + z*v.z;
	}

	public ivector3d cross_product(ivector3d v){
	double xx = y*v.z - z*v.y;
	double yy = z*v.x - x*v.z;
	double zz = x*v.y - y*v.x;
	return new vector3d(xx, yy, zz);
	}

	public static double magnitude(vector3d v){
	double xs = Pow(v.x, 2);
	double ys = Pow(v.y, 2);
	double zs = Pow(v.z, 2);
	return Sqrt(xs + ys + zs); 
	}

}
