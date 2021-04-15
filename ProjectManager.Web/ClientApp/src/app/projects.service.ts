import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Project } from "./project";

@Injectable({
  providedIn: "root",
})
export class ProjectsService {
  constructor(private httpClient: HttpClient) {}

  getAllProjects(): Observable<Project[]> {
    return this.httpClient.get<Project[]>("https://localhost:44327/api/projects", {
      responseType: "json",
    });
  }

  insertProject(newProject: Project): Observable<Project> {
    return this.httpClient.post<Project>(
      "https://localhost:44327/api/projects",
      newProject,
      { responseType: "json" }
    );
  }

  updateProject(existingProject: Project): Observable<Project> {
    return this.httpClient.put<Project>(
      "https://localhost:44327/api/projects/" + existingProject.projectID,
      existingProject,
      { responseType: "json" }
    );
  }

  deleteProject(ProjectID: number): Observable<string> {
    return this.httpClient.delete<string>(
      "https://localhost:44327/api/projects/" + ProjectID
    );
  }
}
