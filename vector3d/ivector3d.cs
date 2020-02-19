public interface ivector3d{
	double x{get; set;}
	double y{get; set;}
	double z{get; set;}
	double dot_product(ivector3d v);
	ivector3d cross_product(ivector3d v);
}
