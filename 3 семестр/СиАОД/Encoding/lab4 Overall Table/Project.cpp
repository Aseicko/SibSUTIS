#include "EncoderHaffman.h"
#include "EncoderFano.h"
#include "EncoderShannon.h"
#include "EncoderGilbertMoore.h"

int main() {
	EncoderHaffman encoder1;
	EncoderFano encoder2;
	EncoderShannon encoder3;
	EncoderGilbertMoore encoder4;

	encoder1.Execute("input.txt");
	encoder2.Execute("input.txt");
	encoder3.Execute("input.txt");
	encoder4.Execute("input.txt");

	return 0;

}
