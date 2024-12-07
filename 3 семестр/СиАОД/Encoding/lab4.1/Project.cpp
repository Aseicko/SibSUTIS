#include "EncoderShannon.h"

int main() {
	EncoderShannon test;

	test.Execute("input.txt");
	test.EncodeText("text.txt");

	return 0;

}
