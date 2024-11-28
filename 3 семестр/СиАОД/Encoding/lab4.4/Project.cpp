#include "EncoderGilbertMoore.h"

int main() {
	EncoderGilbertMoore test;
	
	test.Execute("input.txt");
	test.EncodeText("text.txt");

	return 0;

}
