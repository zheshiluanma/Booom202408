set WORKSPACE=%cd%
set DEFINE=%WORKSPACE%\Defines\__client__.xml
set GEN_CLIENT=%WORKSPACE%\..\__LuBan\Luban.ClientServer\Luban.ClientServer.exe

for /f tokens^=2^ delims^=^" %%t in ('findstr "<topmodule name=.*/>" %%DEFINE%%') do (
    set NAMESPACE=%%t
)

set NAMESPACE=%NAMESPACE:.=\%

%GEN_CLIENT% -j cfg --^
 --define_file %DEFINE% ^
 --input_data_dir %WORKSPACE%\ ^
 --output_code_dir %WORKSPACE%\..\..\Assets\Scripts\Gen\%NAMESPACE% ^
 --output_data_dir  %WORKSPACE%\..\..\Assets\JsonData\%NAMESPACE% ^
 --gen_types code_cs_unity_json,data_json ^
 -s client 

 del .cache.meta

pause