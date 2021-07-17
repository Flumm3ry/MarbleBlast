$buildDirectory = $args[0];
$gameExe = $buildDirectory + "\MarbleBlast.exe";

Start-Process -NoNewWindow -FilePath ${gameExe} -ArgumentList "-mlapi client";
Start-Process -NoNewWindow -FilePath ${gameExe} -ArgumentList "-mlapi host";