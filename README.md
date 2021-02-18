# ClickNLoad2MyJD
A simple console application, which fetches Click'n'Load links and send them directly to a device of your MyJDownloader account.
Works without any browser extension and on every desktop platform!
I made this very much because of missing MyJDownloader browser extension for Safari on Mac OS X.

### Requirements
You need to install the .NET Core 3.1 Runtime, which you can find [here](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Usage
Start the application before opening a web page containing the Click'n'Load link.
On the first application start you have to enter you MyJDownloader account credentials.
After that it will start a small web server listening on port 9666 to handle the
requests required for Click'n'Load to work.

### Credits
Special thanks to some other projects here on GitHub, from which I got inspired
* [bennyborn / ClickNLoadDecrypt](https://github.com/bennyborn/ClickNLoadDecrypt)
* [Cr1TiKa7 / My.Jdownloader.Api](https://github.com/Cr1TiKa7/My.Jdownloader.Api)
