export class StoryUpdate {
    id: number
    title: string
    description: string
    department: string

    constructor(id: number, title: string, description: string, department: string){
        this.id = id
        this.title = title
        this.description = description
        this.department = department
    }
}
