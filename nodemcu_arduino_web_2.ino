
 #include <ESP8266WiFi.h>
#include <SoftwareSerial.h>
const char* ssid="Le 2";
const char* password="37c7ttta";
WiFiServer server(80);
float moisture1;
float moisture2;
float ldr;
float pir;
float temp;
float humidity;
SoftwareSerial ArduinoUno(D2,D3);
 void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
 
    Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("WiFi connected");
  // Start the server
  server.begin();
  Serial.println("Server started");
  // Print the IP address
  Serial.print("Use this URL : ");
  Serial.print("http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");
   ArduinoUno.begin(4800);
  pinMode(D2,INPUT); //input or reciever
  pinMode(D3,OUTPUT); //output or transmitter
}
 void loop() {
  
  WiFiClient client = server.available();
  if (!client) {
    return;
  }
  // Wait until the client sends some data
  Serial.println("new client");
  while(!client.available()){
    delay(1);
  }
  
  String request = client.readStringUntil('\r');
  Serial.println(request);
  client.flush();
  int j=10;
  ArduinoUno.print(j);
  ArduinoUno.println("\n");
  while (!ArduinoUno.available()){
    ArduinoUno.print(j);
    ArduinoUno.println("\n");
  }
  //while(ArduinoUno.available()>0) //data recive from arduino
  //{
   moisture1=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("moisture in field 1 is: ");
      if(moisture1<300)
      { Serial.println(moisture1);
      Serial.println("HIGH");
      //break;
      }
      else{
         Serial.println(moisture1);
      
      Serial.println("LOW");
      //break;
      }
     
  //}
  delay(17);
  ArduinoUno.println(j);
   while (!ArduinoUno.available()){
    ArduinoUno.println(j);
  }
   while(ArduinoUno.available()>0) //data recive from arduino
  {
   moisture2=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("moisture in field 2 is: ");
      if(moisture2<300)
      { Serial.println(moisture2);
      Serial.println("HIGH");
      break;}
      else{
         Serial.println(moisture2);
      
      Serial.println("LOW");
      break;
      }
     
  }
  delay(17);
   ArduinoUno.println(j);
   while (!ArduinoUno.available()){
    ArduinoUno.println(j);
  }
     while(ArduinoUno.available()>0) //data recive from arduino
  {
   ldr=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("Light condition: ");
      if(ldr<200)
      { Serial.println(ldr);
      Serial.println("ITS DARK");
      break;}
      else{
         Serial.println(ldr);
      
      Serial.println("ITS BRIGHT");
      break;
      }
     
  }
  delay(17);
   ArduinoUno.println(j);
   while (!ArduinoUno.available()){
    ArduinoUno.println(j);
  }
     while(ArduinoUno.available()>0) //data recive from arduino
  {
   temp=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("Temperature is: ");
      if(moisture2<300)
      { Serial.println(temp);
      
      break;}
      else{
         Serial.println(temp);
      
      
      break;
      }
     
  }
  delay(17);
   ArduinoUno.println(j);
   while (!ArduinoUno.available()){
    ArduinoUno.println(j);
  }
     while(ArduinoUno.available()>0) //data recive from arduino
  {
   humidity=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("Relative Humidity is: ");
      Serial.print(humidity);
        Serial.println("%");
      
      break;
     
  }
  delay(17);
   ArduinoUno.println(j);
   while (!ArduinoUno.available()){
    ArduinoUno.println(j);
  }
     while(ArduinoUno.available()>0) //data recive from arduino
  {
   pir=ArduinoUno.parseFloat();//pass value to nodemcu and to val variable
   
      Serial.print("Intruder: ");
      if(pir<300)
      { Serial.println(pir);
      Serial.println("PRESENT");
      break;}
      else{
         Serial.println(pir);
      
      Serial.println("NOT PRESENT");
      break;
      }
     
  }
  delay(17);
   client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: text/html");
  client.println("Connnection: close");
  client.println();
  client.println("<!DOCTYPE HTML>");
  client.println("<html>");
  client.println("<meta http-equiv=\"refresh\" content=\"3\">");
  
  client.println("<head>");
  client.println("<title>\"Farm Data\"</title>");

  client.println("</head>");
  
  client.println("<body>");
  client.println("<div>");
  client.println("<img src=\"farm.jpg\">");
  client.println("<h1>Getting Sensor values</h1>");
  client.println("<br />");
  client.println("<style>");
  client.println("h1{font-family: Georgia;  text-align: center;  color: blue; }");
  client.println("h3{font-family: Arial;  color: gray;  font-size: 18px; }");
 
  
  client.println("</style>");
  client.println("<i>");
  client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Moisture in region 1 is ");
  client.println("</i>"); 
  if(moisture1<300.0)
  { 
    client.println("HIGH");
  }
  else if (moisture1>=300)
  { 
    client.println("LOW");
  }
  client.println("</h3>");
  client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Moisture in region 2 is ");
  client.println("</i>"); 
  if(moisture2<300.0)
  { 
    client.println("HIGH");
  }
  else if (moisture2>=300)
  { 
    client.println("LOW");
  }
  
  client.println("</h3>");
  client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Temperature is:  ");
  client.println("</i>"); 
  client.print(temp);
  client.println(" C");
  client.println("</h3>");
  client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Relative Humidity: ");
  client.println("</i>"); 
  client.print(humidity);
  client.println("%");
  client.print("</h3>");
    client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Intruder/Animal: ");
  client.println("</i>"); 
  client.print(pir);
  
  if(pir<200.0)
  { 
    client.println("NOT PRESENT");
  }
  else if (pir>=200)
  { 
    client.println("PRESENT");
  }
 
  client.print("</h3>");
    client.print("<h3>");
  client.println("<i>");
  client.print("&nbsp &nbsp &nbsp &nbsp &nbsp");
  client.print(" Light condition ");
  client.println("</i>"); 
  client.println(ldr);
  if(ldr>250.0)
  { 
    client.println(" ITS BRIGHT");
    
  }
  else if (ldr<=250)
  { 
    client.println(" ITS DARK");
  }
  client.print("</h3>");
  client.println("</div>");
  client.println("</body>");
  client.println("</html>");
  delay(1000);
  Serial.println("Client disconnected");
 
}
