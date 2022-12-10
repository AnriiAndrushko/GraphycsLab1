#version 330

out vec4 outputColor;

uniform vec3 myColor;

void main()
{
    outputColor = vec4(myColor, 1.0);
}