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
rem ������ ��������� NTP ������� Windows
echo ������ ��������� NTP ������� Windows
echo.

#rem -- ���� ������ NTP �������
set ntp_server=time.windows.com

#rem -- ���� ������� ���������� ������� � �������
set ntp_update=2
@echo off
rem -- ������ � �������� ������� �� ��������� 0 �������
echo.
echo =======================================================
echo ������ � �������� ������� �� ��������� 0 �������
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers /ve /t REG_SZ /d 0 /f

rem -- ����������� �������� ������� ���������� �� ������ ��� ������� 0
echo.
echo =======================================================
echo �������� ������� �������� ������� ���������� ������ �������� �� %ntp_server%
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers /v 0 /t REG_SZ /d %ntp_server% /f

rem -- �������� NTP ������
echo.
echo =======================================================
echo �������� NTP ������
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Parameters /v Type /t REG_SZ /d NTP /f

rem -- ������ ������� ������ ����������
echo.
echo =======================================================
echo ������ ������� ������ ���������� %ntp_server%
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Parameters /v NtpServer /t REG_SZ /d %ntp_server%,0x9 /f

rem -- ������������� ������ ����������
echo.
echo =======================================================
echo ������������� ������ ���������� %ntp_update% �����
rem -- ������� ������� � �������
set /a ntp_update*=2
REG ADD HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpClient /v SpecialPollInterval /t REG_DWORD /d %ntp_update% /f

rem -- ������ ������ ������� �������������� ������
echo.
echo =======================================================
echo ������ ������ ������� �������������� ������ 
sc config w32time start= auto

rem -- ���������/������������� �����������/��������� ������ ������� 
echo. && echo======================================================= && echo ������� ����������� ������ ������� && echo. && sc stop w32time && PING -n 5 -w 1000 127.0.0.1 >nul && sc start w32time || echo. && echo ======================================================= && echo ������� ������� ������ ������� && echo. && sc start w32time 

echo.
	:: ��� ������ �� �������. ���� ������ �� ������!!!
*/new ActiveXObject('Shell.Application').ShellExecute (WScript.ScriptFullName,'Admin','','runas',1);
