#include <LiquidCrystal.h>
#include <time.h>
#include <ESP8266WiFi.h>
#include <sys/time.h>                   // struct timeval
#include <coredecls.h>                  // settimeofday_cb()


// define time info
//.........................//
#define TZ              6      // (utc+) TZ in hours
#define DST_MN          60      // use 60mn for summer time in some countries
#define TZ_MN           ((TZ)*60)
#define TZ_SEC          ((TZ)*3600)
#define DST_SEC         ((DST_MN)*60)
timeval cbtime;      // time set in callback
bool cbtime_set = false;
timeval tv;
timespec tp;
time_t now;
uint32_t now_ms, now_us, current_min;
int count; // count time push button ; if count odd, hamonic turn on, if count Parity, hamonic turn off
// for testing purpose:
extern "C" int clock_gettime(clockid_t unused, struct timespec *tp);

//......................//
#define PTM(w) \

#define TimeStop20h 14*3600+40*60
#define TimeStop22h 22*3600
#define TimeStop23h 23*3600

#define TimeStart8h30 8.5*3600
#define TimeStart13h 13*3600

// Replace with your network credentials
const char* ssid     = "ThePC";
const char* password = "khongcopass";//"yzwCv5hJ";
const int pinOut=5;// D1
const int pinIN=4; //D2
String dataString;
bool _userON;
char statusCommand=0x00;
uint32_t* SetTimeHourList;
// Set web server port number to 80
WiFiServer server(8880);

 void time_is_set (void)
{
  gettimeofday(&cbtime, NULL);
  cbtime_set = true;
}

void configDateTime(){
  settimeofday_cb(time_is_set);
  configTime(TZ_SEC, DST_SEC, "pool.ntp.org");
}

void GetCurrentTime()
{
  gettimeofday(&tv, nullptr);
  clock_gettime(0, &tp);
  now = time(nullptr);
  now_ms = millis();
  now_us = micros();

  // localtime / gmtime every second change
  static time_t lastv = 0;
  if (lastv != tv.tv_sec) {
    lastv = tv.tv_sec;
  }
  current_min=localtime(&now)->tm_hour*3600+localtime(&now)->tm_min*60+ localtime(&now)->tm_sec;
  Serial.print("curent time value="); //This is where we actually print the time string.
  Serial.println(current_min); //This is where we actually print the time string.
  ControlHarnomicFllowTime(current_min);
  delay(500);
}

void SetUpServer()
{
  IPAddress local_IP(192, 168, 137, 214);
// Set your Gateway IP address
  IPAddress gateway(192, 168, 137, 1);
  IPAddress subnet(255, 255, 255, 0);
  IPAddress primaryDNS(8, 8, 8, 8);   //optional
  IPAddress secondaryDNS(8, 8, 4, 4); //optional
  // Configures static IP address
  if (!WiFi.config(local_IP, gateway, subnet,primaryDNS,secondaryDNS )) {
    Serial.println("STA Failed to configure");}

 }

void setup() {
  SetTimeHourList[0]=18*3600;
  SetTimeHourList[1]=19*3600;
  SetTimeHourList[2]=20*3600;
  SetTimeHourList[3]=21*3600;
  SetTimeHourList[4]=22*3600;

  count=0;
  pinMode(pinOut, OUTPUT);     // Initialize the LED_BUILTIN pin as an output
  pinMode(pinIN, INPUT);    // sets the digital pin 7 as input
  Serial.begin(9600);
  digitalWrite(pinOut, LOW);
  // Initialize the output variables as outputs
  // Connect to Wi-Fi network with SSID and password
  Serial.print("Connecting to ");
  Serial.println(ssid);
  SetUpServer();
  configDateTime();
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  // Print local IP address and start web server
  Serial.println("");
  Serial.println("WiFi connected.");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  server.begin();
}

void ControlHarnomicFllowTime(uint32_t sec)
{

   int value = digitalRead(pinIN);   // read the input pin
     if(((sec>SetTimeHourList[0] && (sec< SetTimeHourList[0]+2))||
     (sec>SetTimeHourList[1] && (sec< SetTimeHourList[1]+2))||
     (sec>SetTimeHourList[2] && (sec< SetTimeHourList[2]+2))||
     (sec>SetTimeHourList[3] && (sec< SetTimeHourList[3]+2))||
     (sec>SetTimeHourList[4] && (sec< SetTimeHourList[4]+2)))&& value==HIGH)// control on hamonic
     {
        Serial.println("Harmonic OFF");
        digitalWrite(pinOut, HIGH);
        delay(500);
        digitalWrite(pinOut, LOW);

     }
}

void ControlHarnomicFllowMessage(String datastring, char status, WiFiClient client)
{
     int value = digitalRead(pinIN);   // read the input pin
     if(status=='1'&& value==LOW)// control on hamonic
     {
        Serial.println("Harmonic on");
        digitalWrite(pinOut, HIGH);
        delay(500);
        digitalWrite(pinOut, LOW);

        int value = digitalRead(pinIN);   // read the input pin
        String valueString=(String)value;
        Serial.print("valude string = ");
        Serial.println(valueString);
        datastring+=String(value);
        client.println(datastring) ;
        Serial.print("Send hamonic status: ");
        Serial.println(datastring);

     }
    else if(status=='0'&& value==HIGH)// control off hamoic
     {
        Serial.println("Harmonic off");
        digitalWrite(pinOut, HIGH);
        delay(500);
        digitalWrite(pinOut, LOW);
        int value = digitalRead(pinIN);   // read the input pin
        String valueString=(String)value;
        Serial.print("valude string = ");
        Serial.println(valueString);
        datastring+=String(value);
        client.println(datastring) ;
        Serial.print("Send hamonic status: ");
        Serial.println(datastring);
     }
     else if(status=='2')// check status on-off and send to client
     {
      int value = digitalRead(pinIN);   // read the input pin
      String valueString=(String)value;
      Serial.print("valude string = ");
      Serial.println(valueString);
      datastring+=String(value);
      client.println(datastring) ;
      Serial.print("Send hamonic status: ");
      Serial.println(datastring);
      }
}

void ReadData(WiFiClient client){
         char c = client.read();             // read a byte, then
         Serial.write(c);
         dataString+=(String)c;
        if(c==0x3A) {
          statusCommand = client.read();             // read a byte, then
          Serial.print("Data command = ");
          Serial.write(statusCommand);
          Serial.println('\n');
          ControlHarnomicFllowMessage(dataString, statusCommand,client);
          client.stopAllExcept(&client);
          Serial.println("Client disconnected.");
          }
        if(c==0x2C)
        {
          Serial.println(" Recives set time commmand.");
          SetTimeHourList=SetTimeFromClient(dataString,client);
        }
  }
  
uint32_t ReadSetTimeitem(WiFiClient client){
   String timeString="";
   uint32_t timerecive=3600*18;
    timeString += (char)(client.read());             // read a byte, then
    timeString += (char)(client.read());             // read a byte, then
    client.read();// read char ','
    Serial.println(timeString);
    timerecive=(uint32_t)(3600*timeString.toInt());
    return timerecive;
  }
  
uint32_t* SetTimeFromClient(String dataString,WiFiClient client){
      String timeString="";
      float  myNumber =0;
    bool checkNumberCorrect=true;
      for(int i=0; i<5;i++)
       {
          SetTimeHourList[i]=ReadSetTimeitem(client);
          Serial.printf("My number %d =" ,i);
          Serial.println(SetTimeHourList[i]);
          if(SetTimeHourList[i]>0 && SetTimeHourList[i]<24*3600)
          {
            checkNumberCorrect=true;
          } 
          else
          {
            checkNumberCorrect=false;
          }
        }
      if(checkNumberCorrect==true)
      {
          dataString+="1";
          client.println(dataString) ;
          Serial.print("Send hamonic SetTime Status: ");
          Serial.println(dataString);
          return SetTimeHourList;
      }
      else
      {
          dataString+="0";
          client.println(dataString) ;
          Serial.print("Send hamonic SetTime Status: ");
          Serial.println(dataString);
          return SetTimeHourList;
     }
  }
  
void loop(){
  GetCurrentTime();
  WiFiClient client = server.available();   // Listen for incoming clients
  if (client) {                             // If a new client connects,
    Serial.println("New Client.");          // print a message out in the serial port
    String currentLine = "";                // make a String to hold incoming data from the client
    while (client.connected())
    {            // loop while the client's connected
      if (client.available())
      {             // if there's bytes to read from the client,
        Serial.println(" Client avaiable");          // print a message out in the serial port
        ReadData(client);
      }
    }
       Serial.println(dataString);
       dataString="";
  }
}
