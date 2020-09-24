#include <Keyboard.h>
#include <PCA9505_9506.h>


  #define KEYPAD_0 234
  #define KEYPAD_1 225
  #define KEYPAD_2 226
  #define KEYPAD_3 227
  #define KEYPAD_4 228
  #define KEYPAD_5 229
  #define KEYPAD_6 230
  #define KEYPAD_7 231
  #define KEYPAD_8 232
  #define KEYPAD_9 233
  #define KEYPAD_ASTERIX 221
  #define KEYPAD_ENTER 224
  #define KEYPAD_MINUS 222
  #define KEYPAD_PERIOD 235
  #define KEYPAD_PLUS 223
  #define KEYPAD_SLASH 220
  #define KEY_DOWN 217
  #define KEY_LEFT 216
  #define KEY_UP 218
  #define KEY_RIGHT 215
  
PCA9505_06 GPIO;

bool online = true;

void setup() {
  GPIO.begin(0x27);;
}

void loop() {
  byte buff[1] = {0};

  if (online) {
    //com1
 if (GPIO.digitalRead(7)==0) {
    Keyboard.press(KEY_INSERT);
    delay(300);
    Keyboard.releaseAll();  
 } 
 //com2
  if (GPIO.digitalRead(8)==0) {
    Keyboard.press(KEY_HOME);
    delay(300);
    Keyboard.releaseAll(); 
 } 
 //iff
  if (GPIO.digitalRead(9)==0) {
    Keyboard.press(KEY_PAGE_DOWN);
    delay(300);
    Keyboard.releaseAll(); 
 } 
 //list
  if (GPIO.digitalRead(10)==0) {
    Keyboard.press(KEY_PAGE_UP);
    delay(300);
    Keyboard.releaseAll();
 } 
 //aa
  if (GPIO.digitalRead(11)==0) {
    Keyboard.press(KEYPAD_SLASH);
    delay(300);
    Keyboard.releaseAll();
 } 
 //ag
  if (GPIO.digitalRead(6)==0) {
    Keyboard.press(KEYPAD_ASTERIX);
    delay(300);    
    Keyboard.releaseAll(); 
 } 

  } else {
    Serial.print('R');
    Serial.readBytes(buff,1);
    if ( buff[0] == 'G' ) {
      online = true;
      Serial.print("A"); 
    }
  }

  delay(10);
}
