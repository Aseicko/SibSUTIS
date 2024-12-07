#include "EncoderHaffman.h"

int main() {
	EncoderHaffman test;

	test.Execute("input.txt");
	test.EncodeText("text.txt");

	return 0;

}
