rem 创建objs目录，用来存放生成的.class文件
@if not exist objs mkdir objs 
rem 创建output目录，用来存放最后编译成的.jar文件
@if not exist output mkdir output 
rem javac命令，生成.class文件到objs目录中
javac -source 1.6 -target 1.6 -nowarn -encoding utf8 -cp "./android_sdk.jar;./unity_classes.jar" -d "./objs" UnityPlayerActivity.java MyActivity.java 
rem 进入objs目录
cd objs
rem 讲objs目录中所有的.class文件打包成.jar文件
jar cvf ../output/game.jar ./com/linxinfa/game/*