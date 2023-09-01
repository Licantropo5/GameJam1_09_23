using System.Collections.Generic;
using GameJam;

public static class Extension {
	public static List<Path> OrderByPriority(this List<Path> paths) {
		for (int i = 0; i < paths.Count; i++) {
			if (paths[i].GetPriority() != i) {
				var temp = paths[i];
				foreach (Path path in paths) {
					if (path.GetPriority() == i) {
						paths[paths.IndexOf(path)] = temp;
						paths[i] = path;
						break;
					}
				}
			}
		}
		return paths;
	}
}