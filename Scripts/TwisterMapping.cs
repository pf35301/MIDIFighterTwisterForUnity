public static class TwisterMapping {

    public static Vector HandCameraTransform = new Vector(0, 1, 2); 
    public static Vector MoveCameraTransform = new Vector(4, 5, 6); 
    public static Vector RotateCameraTransform = new Vector(8, 9, 10); 

    public class Vector {
        int x;
        int y;
        int z;

        public Vector(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
