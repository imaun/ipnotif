# IpNotif
Notify about IP changes on a PC.

This includes a library for fetching data about local & public IP addresses. In addition to the library, a Console app and a Winform app developed to used by end-users.

## How to use :
Run ipnotif.exe without any params to see your current public IP information.
Available params :
* `ipnotif local` or `ipnotif localhost` : shows Ipv4 and Ipv6 local addresses
* `ipnotif 192.168.1.1` : shows info about 192.168.1.1 ip address, replace with you desired address.

Run ipnotif.Gui.exe if you want to get notification when your public ip changes unexpctedly. The app will notify you via system tray, so don't remove it from there!

## Development
IpNotif uses smartip.io service to get information about any public IP addresses. You can get your `ApiKey` from smartip.io and replace it in source code. The external IP provider uses other notable services, if available, to get your public IP address.
* checkip.amazonaws.com
* ipinfo.io/ip
* api.ipify.org
* icanhazip.com
* wtfismyip.com/text
* bot.whatismyipaddress.com
* checkip.dyndns.org

