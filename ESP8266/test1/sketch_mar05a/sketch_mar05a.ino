#include <ESP8266WiFi.h>
#include <time.h>                       // time() ctime()
#include <sys/time.h>                   // struct timeval
#include <coredecls.h>                  // settimeofday_cb()

////////////////////////////////////////////////////////
const char* SSID     = "ThePC";
const char* SSIDPWD = "khongcopass";
#define TZ              7      // (utc+) TZ in hours
#define DST_MN          60      // use 60mn for summer time in some countries

////////////////////////////////////////////////////////

#define TZ_MN           ((TZ)*60)
#define TZ_SEC          ((TZ)*3600)
#define DST_SEC         ((DST_MN)*60)

timeval cbtime;      // time set in callback
bool cbtime_set = false;

void time_is_set (void)
{
  gettimeofday(&cbtime, NULL);
  cbtime_set = true;
}

void setup() {
  Serial.begin(115200);
  settimeofday_cb(time_is_set);


  configTime(TZ_SEC, DST_SEC, "pool.ntp.org");
  WiFi.begin(SSID, SSIDPWD);
}

// for testing purpose:
extern "C" int clock_gettime(clockid_t unused, struct timespec *tp);

#define PTM(w) \
//  Serial.print(":" #w "="); \                             //Some extra prints I've cut out..
//  Serial.print(tm->tm_##w);

void printTm (const char* what, const tm* tm) {
//  Serial.print(what);
  PTM(isdst); PTM(yday); PTM(wday);
  PTM(year);  PTM(mon);  PTM(mday);
  PTM(hour);  PTM(min);  PTM(sec);
}

timeval tv;
timespec tp;
time_t now;
uint32_t now_ms, now_us;

void loop() {

  gettimeofday(&tv, nullptr);
  clock_gettime(0, &tp);
  now = time(nullptr);
  now_ms = millis();
  now_us = micros();

  // localtime / gmtime every second change
  static time_t lastv = 0;
  if (lastv != tv.tv_sec) {
    lastv = tv.tv_sec;
    printTm("localtime", localtime(&now));
    printTm("gmtime   ", gmtime(&now));
  }

  Serial.println(ctime(&now)); //This is where we actually print the time string.

  // simple drifting loop
  delay(1000);
}
