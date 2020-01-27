@set @x=0; /*
@echo off
ver |>NUL find /v "5." && if "%~1"=="" cscript.exe //nologo //e:jscript "%~f0"& exit /b


net time \\ADMIN-7OJJJDEEA /set /y 
net time /setsntp:88.147.254.232

w32tm \\setsntp:88.147.254.232
net start w32time

w32tm /config /manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update
w32tm /config /syncfromflags:manual /manualpeerlist:88.147.254.232 /set 
w32time /config /manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update



w32tm /config /update

net time /setsntp:88.147.254.232



net stop w32time && net start w32time
w32tm /resync


@echo off
rem Скрипт настройки NTP клиента Windows
echo Скрипт настройки NTP клиента Windows
echo.

#rem -- ввод адреса NTP сервера
set ntp_server=time.windows.com

#rem -- ввод периуда обновления времени в минутах
set ntp_update=2
@echo off
rem -- задаем в качестве сервера по умолчанию 0 элемент
echo.
echo =======================================================
echo Задаем в качестве сервера по умолчанию 0 элемент
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers /ve /t REG_SZ /d 0 /f

rem -- редактируем значение сервера обновлений из списка под новером 0
echo.
echo =======================================================
echo Изменяем текущие значение сервера обновлений списка серверов на %ntp_server%
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers /v 0 /t REG_SZ /d %ntp_server% /f

rem -- включаем NTP клиент
echo.
echo =======================================================
echo Включаем NTP клиент
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Parameters /v Type /t REG_SZ /d NTP /f

rem -- задаем текущий сервер обновления
echo.
echo =======================================================
echo Задаем текущий сервер обновления %ntp_server%
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Parameters /v NtpServer /t REG_SZ /d %ntp_server%,0x9 /f

rem -- устонавливаем периуд обновления
echo.
echo =======================================================
echo Устонавливаем периуд обновления %ntp_update% минут
rem -- перевод времени в секунды
set /a ntp_update*=2
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpClient /v SpecialPollInterval /t REG_DWORD /d %ntp_update% /f

rem -- задаем службе времени автоматический запуск
echo.
echo =======================================================
echo Задаем службе времени автоматический запуск 
sc config w32time start= auto

rem -- запускаем/перезапускаем незапущеную/зупущеную службу времени 
echo. && echo======================================================= && echo Попытка перезапуска службы времени && echo. && sc stop w32time && PING -n 5 -w 1000 127.0.0.1 >nul && sc start w32time || echo. && echo ======================================================= && echo Попытка запуска службы времени && echo. && sc start w32time 

echo.
	:: Эту строку не трогать. Ниже ничего не писать!!!
*/new ActiveXObject('Shell.Application').ShellExecute (WScript.ScriptFullName,'Admin','','runas',1);
