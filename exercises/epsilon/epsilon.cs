using System;
using static System.Console;


class epsilon{
	public static int Main(){
	WriteLine("--- Ex 1 ---");
	findMax();
	WriteLine("--- Ex 2 ---");
	small();
	WriteLine("--- Ez 3 ---");
	harmonic();
	return 0;
	}

	public static void findMax(){
	WriteLine($"Acording to computer the max integervalue is {int.MaxValue}");
	int i = 2000000000;
	while(i + 1 > i){
	i++;}
	WriteLine($"Acording to this bandit whileloop, the max intervalue us {i}");
	WriteLine($"Comparing this gives a difference of {i-int.MaxValue}");
	int k = -200000000;
	while(k - 1 < k){
	k--;}
	WriteLine($"Comparing with minimum value, we get a difference of {k-int.MinValue}, with bot values {k}");	
	}

	public static void small(){
	double x = 1;
	while(1+x!=1){
	x/=2;}
	x*=2;
	WriteLine($"The smallest number from a double is {x}");
	WriteLine($"This is the same as                  {System.Math.Pow(2,-52)}");
	float y = 1F;
	while((float)(1F+y)!=1F){
	y/=2F;}
	y*=2F;
	WriteLine($"The smallest number from a float is {y}");
	WriteLine($"This is the same as                 {System.Math.Pow(2,-23)}");
	}

	public static void harmonic(){
	int max = int.MaxValue/2;
	float float_sum_up = 1F;
	for(int i = 2; i > 0; i++){
	float_sum_up += 1F/i;}
	WriteLine($"float_sum_up = {float_sum_up}");
	
	float float_sum_down = 1F/max;
	for(int i = max; i > 0; i--){
	float_sum_down += 1F/i;}
	WriteLine($"float_sum_down = {float_sum_down}");
	
	}
}
